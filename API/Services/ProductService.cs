using API.Repository;
using Core.DTO;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using Microsoft.AspNetCore.Hosting;
using API.Interfaces.Services;

namespace API.Services
{
    public class ProductService : IProductService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IProductRepository _productRepository;

        public ProductService(IWebHostEnvironment environment, IProductRepository productRepository)
        {
            _environment = environment;
            _productRepository = productRepository;
        }

        public async Task<string> ImportExcelAsync(IFormFile file)
        {
            if (file.Length == 0 || file == null)
            {
                return "Please upload a valid Excel file.";
            }

            using (var stream = new MemoryStream())
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0]; // Первая вкладка
                    int rowCount = worksheet.Dimension.Rows;
                    var drawings = worksheet.Drawings;

                    for (int row = 2; row <= rowCount; row++) // Начиная со второй, первая названиеu
                    {
                        var productName = worksheet.Cells[row, 1].Text;
                        var price = decimal.Parse(worksheet.Cells[row, 2].Text);
                        var brandId = int.Parse(worksheet.Cells[row, 3].Text);
                        var count = int.Parse(worksheet.Cells[row, 5].Text);
                        string imagePath = ""; // По умолчанию пустой путь

                        // Поиск изображений, привязанных к ячейкам в четвертом столбце
                        foreach (var picture in drawings.OfType<ExcelPicture>())
                        {
                            // Проверяем, привязано ли изображение к текущей строке и четвертому столбцу
                            if (picture.From.Row + 1 == row && picture.From.Column + 1 == 4)
                            {
                                // Генерация уникального имени файла с правильным расширением
                                var extension = picture.Image.Type.ToString().ToLower();
                                var uniqueFileName = Guid.NewGuid().ToString() + "." + extension;
                                var filePath = Path.Combine(_environment.WebRootPath, "images", uniqueFileName);

                                // Создаем папку, если она не существует
                                if (!Directory.Exists(Path.Combine(_environment.WebRootPath, "images")))
                                {
                                    Directory.CreateDirectory(Path.Combine(_environment.WebRootPath, "images"));
                                }

                                // Извлекаем байты изображения и сохраняем их на сервер
                                await System.IO.File.WriteAllBytesAsync(filePath, picture.Image.ImageBytes);

                                // Устанавливаем путь к изображению
                                imagePath = $"/images/{uniqueFileName}";
                            }
                        }

                        var productDto = new ProductDto
                        {
                            Name = productName,
                            Price = price,
                            BrandId = brandId,
                            ImagePath = imagePath, // Записываем путь к изображению в DTO
                            Count = count,
                        };

                        await _productRepository.CreateProductAsync(productDto);
                    }
                }
            }

            return "Products imported successfully.";
        }
    }
}
