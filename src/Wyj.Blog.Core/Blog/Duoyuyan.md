

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
                    
                     "TagTagName": "TagName",
                    "TagTagNameInputDesc": "请输入TagName",
                     
                    
                     "TagDisplayName": "DisplayName",
                    "TagDisplayNameInputDesc": "请输入DisplayName",
                     
					                     
                    "Tag": "",
                    "ManageTag": "管理",
                    "QueryTag": "查询",
                    "CreateTag": "添加",
                    "EditTag": "编辑",
                    "DeleteTag": "删除",
                    "BatchDeleteTag": "批量删除",
                    "ExportTag": "导出",
                    "TagList": "列表",
                     //的多语言配置==End
                    


```


### 英语本地化的内容English localized content
找到Json文件夹下的Blog.json文件，复制以下代码进入即可。
```json
             //的多语言配置==>英文
                    
                     "TagTagName": "TagTagName",
                    "TagTagNameInputDesc": "Please input your TagTagName",
                     
                    
                     "TagDisplayName": "TagDisplayName",
                    "TagDisplayNameInputDesc": "Please input your TagDisplayName",
                     
					                     
                    "Tag": "Tag",
                    "ManageTag": "ManageTag",
                    "QueryTag": "QueryTag",
                    "CreateTag": "CreateTag",
                    "EditTag": "EditTag",
                    "DeleteTag": "DeleteTag",
                    "BatchDeleteTag": "BatchDeleteTag",
                    "ExportTag": "ExportTag",
                    "TagList": "TagList",
                     //的多语言配置==End
                    




```