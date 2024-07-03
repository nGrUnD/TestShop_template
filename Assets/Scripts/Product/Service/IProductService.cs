using System.Collections.Generic;
using Cysharp.Threading.Tasks;

public interface IProductService
{
    UniTask<List<Chair>> GetProductsAsync();
}