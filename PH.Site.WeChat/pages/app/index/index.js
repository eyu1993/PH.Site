// pages/mall/mall.js
Page({

  /**
   * 页面的初始数据
   */
  data: {
    Apps: [{
        "AppId": "0b64af10-f1d0-6cd0-647f-160c50326f9d",
        "AppName": "qq",
        "Image": "qq image",
        "CodeUrl": null,
        "Description": null,
        "Category": [{
            "CategoryId": "e86aab6e-d465-dcb4-b6c0-5b744488cced",
            "Url": "http://qq.com",
            "Name": "windows",
            "Icon": "windows icon",
            "QRCode": null,
            "CreateDate": "2018-05-20T10:53:21.313",
            "UpdateDate": "2018-05-20T10:53:21.313"
          },
          {
            "CategoryId": "3c0b7247-8472-a11b-1a8c-b64137f28ba1",
            "Url": "http://android.qq.com",
            "Name": "android",
            "Icon": "android icon",
            "QRCode": null,
            "CreateDate": "2018-05-20T10:56:56.843",
            "UpdateDate": "2018-05-20T10:56:56.843"
          }
        ]
      },
      {
        "AppId": "b6135886-6807-6721-eebf-a3f9a4bf2713",
        "AppName": "word",
        "Image": "word-image",
        "CodeUrl": null,
        "Description": null,
        "Category": []
      },
      {
        "AppId": "bfc10524-dfe5-232c-9314-bcd22defb552",
        "AppName": "ppt",
        "Image": "ppt-image",
        "CodeUrl": null,
        "Description": null,
        "Category": []
      },
      {
        "AppId": "a7c633d6-33bb-680a-9a23-f9a335246511",
        "AppName": "excel",
        "Image": "excel-image",
        "CodeUrl": null,
        "Description": null,
        "Category": [{
            "CategoryId": "e86aab6e-d465-dcb4-b6c0-5b744488cced",
            "Url": "https://www.json.cn/",
            "Name": "windows",
            "Icon": "windows icon",
            "QRCode": null,
            "CreateDate": "2018-08-11T22:27:48.833",
            "UpdateDate": "2018-08-11T22:27:48.833"
          },
          {
            "CategoryId": "459fefe1-2d60-f58d-d019-7ca7346f5191",
            "Url": "https://www.json.cn/",
            "Name": "wechat",
            "Icon": "wechat icon",
            "QRCode": null,
            "CreateDate": "2018-08-11T22:28:02.21",
            "UpdateDate": "2018-08-11T22:28:02.21"
          },
          {
            "CategoryId": "01880465-9010-084c-075e-9263507b66ba",
            "Url": "https://www.json.cn/",
            "Name": "web",
            "Icon": "web icon",
            "QRCode": null,
            "CreateDate": "2018-08-11T22:28:12.973",
            "UpdateDate": "2018-08-11T22:28:12.973"
          },
          {
            "CategoryId": "3c0b7247-8472-a11b-1a8c-b64137f28ba1",
            "Url": "https://www.json.cn/",
            "Name": "android",
            "Icon": "android icon",
            "QRCode": null,
            "CreateDate": "2018-08-11T22:28:22.32",
            "UpdateDate": "2018-08-11T22:28:22.32"
          },
          {
            "CategoryId": "f4049036-ace3-95e5-a0c9-e191983baecf",
            "Url": "https://www.json.cn/",
            "Name": "ios",
            "Icon": "ios icon",
            "QRCode": null,
            "CreateDate": "2018-08-11T22:28:32.177",
            "UpdateDate": "2018-08-11T22:28:32.177"
          }
        ]
      }
    ]
  },
  /**
   * 生命周期函数--监听页面加载
   */
  Con: function(appId) {
    console.log(appId)
  }
})