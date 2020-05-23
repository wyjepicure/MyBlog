

# 配置52ABP-PRO的多语言
 
 
**请注意：**
- 从52ABP-PRO 2.5.0的版本开始默认采用json配置多语言
- 属性名和字段不能重复否则框架会验证失败，需要你删除重复的键名

## Json的配置方法如下

在Blog.Core类库中，找到路径为 Localization->SourceFiles->Json文件夹下的对应文件

### 中文本地化的内容Chinese localized content

找到Json文件夹下的Blog-zh-Hans.json文件，复制以下代码进入即可。

> 请注意防止键名重复，产生异常

```json
                    //的多语言配置==>中文
"PostId": "PostId",
"TagId": "TagId",
					                     
                    "PostTag": "",
                    "ManagePostTag": "管理",
                    "QueryPostTag": "查询",
                    "CreatePostTag": "添加",
                    "EditPostTag": "编辑",
                    "DeletePostTag": "删除",
                    "BatchDeletePostTag": "批量删除",
                    "ExportPostTag": "导出",
                    "PostTagList": "列表",
                     //的多语言配置==End
                    


```


### 英语本地化的内容English localized content
找到Json文件夹下的Blog.json文件，复制以下代码进入即可。
```json
             //的多语言配置==>英文
"PostId": "PostId",
"TagId": "TagId",
					                     
                    "PostTag": "PostTag",
                    "ManagePostTag": "ManagePostTag",
                    "QueryPostTag": "QueryPostTag",
                    "CreatePostTag": "CreatePostTag",
                    "EditPostTag": "EditPostTag",
                    "DeletePostTag": "DeletePostTag",
                    "BatchDeletePostTag": "BatchDeletePostTag",
                    "ExportPostTag": "ExportPostTag",
                    "PostTagList": "PostTagList",
                     //的多语言配置==End
                    




```