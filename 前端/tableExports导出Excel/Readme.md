文件夹中的两个文件已经解决了中文乱码和可以自己命名文件的问题



前端导出的语句

```javascript
//导出到Excel文件
                    exportExcel: function () {
                        var itemCode = $("#select-items option:selected").text().split('_')[0];
                        console.log(itemCode);
                        var tableid = "grid-checklist";
                        var dd = $("#gbox_" + tableid + ' .ui-jqgrid-htable thead');
                        var ee = $('#' + tableid);
                        ee.find('.jqgfirstrow').remove();//干掉多余的无效行
                        ee.find('tbody').before(dd);//合并表头和表数据
                        ee.find('tr.ui-search-toolbar').remove();//干掉搜索框
                        ee.find('.cancle').remove();
                        ee.tableExport({ type: 'excel', escape: 'false',htmlContent:'true', fileName: itemCode + ' 药品盘点' });
                        var a = $("#" + tableid).find('thead');//把合并后的表头和数据拆分
                        $("#gbox_" + tableid + ' .ui-jqgrid-htable').append(a);
                    },
```

