using KassaLibrary.PrdoukInfo;

namespace KassaLibrary.FileInfo
{
    public interface IFile 
    {
        List<Product> LoadProductsFromFile();
    }
}