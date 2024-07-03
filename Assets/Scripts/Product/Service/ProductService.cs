using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class ProductService : IProductService
{
    public async UniTask<List<Chair>> GetProductsAsync()
    {
        var response = await UnityWebRequest.Get("https://impulsedao.xyz/warpacks/api/tests/get_shopitems_list.php")
            .SendWebRequest();
        if (response.result != UnityWebRequest.Result.Success)
        {
            throw new Exception(response.error);
        }

        var productsJson = response.downloadHandler.text;
        var chairList = JsonUtility.FromJson<ChairList>(productsJson);
        Debug.Log(productsJson);
        return chairList.chairs;
    }
}