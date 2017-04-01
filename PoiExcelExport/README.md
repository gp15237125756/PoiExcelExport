# PoiExcelExport


PoiExcelExport实现了`Java POI`对`xlsx`文件的導出功能的封装，实现了根據导出excel模板类定义，自动填充excel的功能。

该类库可以增加自定义cell样式和字体样式进行扩展。

# 注意

该poi库使用注解类作为输出excel模板，如有需要，可以使用xml格式的模板。


## 应用场景

  该类库主要用应用场景是在数据中心做导出功能，目前业务较为简单，所以没有对导出到excel模板显示的数据做类型校验，后期可以进行扩展。


## 依赖

PoiExcelExport依赖于`Apache POI 3.8`类库。

## 使用说明

- 使用示例请参考`com.ld.datacenter.service/CollectionStatisticService/exportCategory()`测试用例。

  
***
  
	List<CollectionContrastDto> chartData=this.collectionCategoryQuarterContrast(year);
			ExportBuilder builder=new ExcelExportService.Builder<CollectionContrastDto>("/com/ld/datacenter/service/馆藏分类季对比.xlsx","馆藏分类季度对比",chartData,CollectionContrastDto.class)
					.setYear(year)
					.setSvg(svgCode)
					.setPictureStartCol(1)
					.setPictureEndCol(14)
					.setPictureStartRow(8)
					.setPictureEndRow(20)
					.build();
			return Optional.of(builder.writeStreamFromTemplate(TempCategory.class));


***

### 使用方式

- 1.取得数据

       List<CollectionContrastDto> chartData=this.collectionCategoryQuarterContrast(year);
       
- 2.输入参数，构建输出流

			ExportBuilder builder=new ExcelExportService.Builder<CollectionContrastDto>("/com/ld/datacenter/service/馆藏分类季度对比.xlsx","馆藏分类季度对比",chartData,CollectionContrastDto.class)
					.setYear(year)
					.setSvg(svgCode)
					.setPictureStartCol(1)
					.setPictureEndCol(14)
					.setPictureStartRow(8)
					.setPictureEndRow(20)
					.build();
			return Optional.of(builder.writeStreamFromTemplate(TempCategory.class));


### 注册新的样式

- 注册的新的cell样式类型类必须 实现  `ICellStyleFactory` 接口。

- 注册的新的cell字体类型类必须实现  `IFontFactory` 接口。

- 添加cell格子样式,修改XSSFCellStyleLib类，增加以下代码 
  
  	
     	convert.convert(CellStyle.STANDARD, new TextCellStyleImpl(wb),this);


	
例如，XSSFFontStyleLib中添加以下代码，表示增加了三种格子样式：

		 
			 ICellStyleConvert convert=new CellStyleConvert(); <br />  
			 //添加cell樣式 <br />  
			 convert.convert(CellStyle.NONE, new DefaultCellStyleImpl(wb));<br />  
			 convert.convert(CellStyle.DEFAULT, new DefaultCellStyleImpl(wb));<br />  
			 convert.convert(CellStyle.STANDARD, new TextCellStyleImpl(wb));<br />  
		 



### 实体对象

实体类必须标注@ExcelEntity注解， 同时需要填充的字段标注@EntityAttribute注解


	@ExcelEntity(row=4,yrPos={1,13},yrCellStyle=CellStyle.STANDARD)
	public class TempCategory {

	@EntityAttribute(columnName="70后艺术",required=true,col=2,row={3,4,5,6},merge=false,broken=false,cellStyle=CellStyle.STANDARD,fontStyle=FontStyle.COLOR)
	private String afterSeventy;
	
	@EntityAttribute(columnName="瓷杂",required=true,col=3,row={3,4,5,6},merge=false,broken=false,cellStyle=CellStyle.STANDARD,fontStyle=FontStyle.COLOR)
	private String  porcelainhethrd;
	
	@EntityAttribute(columnName="古代书画",required=true,col=4,row={3,4,5,6},merge=false,broken=false,cellStyle=CellStyle.STANDARD,fontStyle=FontStyle.COLOR)
	private String  ancientPatings;
	
	@EntityAttribute(columnName="红色经典",required=true,col=5,row={3,4,5,6},merge=false,broken=false,cellStyle=CellStyle.STANDARD,fontStyle=FontStyle.COLOR)
	private String  redClassic;
	
	@EntityAttribute(columnName="近现代书画",required=true,col=6,row={3,4,5,6},merge=false,broken=false,cellStyle=CellStyle.STANDARD,fontStyle=FontStyle.COLOR)
	private String  modernPainting;
	
	@EntityAttribute(columnName="老油画",required=true,col=7,row={3,4,5,6},merge=false,broken=false,cellStyle=CellStyle.STANDARD,fontStyle=FontStyle.COLOR)
	private String  oldOilPainting;
	
	@EntityAttribute(columnName="连环画",required=true,col=8,row={3,4,5,6},merge=false,broken=false,cellStyle=CellStyle.STANDARD,fontStyle=FontStyle.COLOR)
	private String  comicsandother;
	
	@EntityAttribute(columnName="外国艺术",required=true,col=9,row={3,4,5,6},merge=false,broken=false,cellStyle=CellStyle.STANDARD,fontStyle=FontStyle.COLOR)
	private String  otherForeignArt;
	
	@EntityAttribute(columnName="现当代书画",required=true,col=10,row={3,4,5,6},merge=false,broken=false,cellStyle=CellStyle.STANDARD,fontStyle=FontStyle.COLOR)
	private String  contemporaryArt;
	
	@EntityAttribute(columnName="亚洲艺术",required=true,col=11,row={3,4,5,6},merge=false,broken=false,cellStyle=CellStyle.STANDARD,fontStyle=FontStyle.COLOR)
	private String  asianArt;
	
	@EntityAttribute(columnName="国外古董",required=true,col=12,row={3,4,5,6},merge=false,broken=false,cellStyle=CellStyle.STANDARD,fontStyle=FontStyle.COLOR)
	private String  foreignAntique;
	
	@EntityAttribute(columnName="当代水墨",required=true,col=13,row={3,4,5,6},merge=false,broken=false,cellStyle=CellStyle.STANDARD,fontStyle=FontStyle.COLOR)
	private String  contemporaryInk;
	
	@EntityAttribute(columnName="其他",required=true,col=14,row={3,4,5,6},merge=false,broken=false,cellStyle=CellStyle.STANDARD,fontStyle=FontStyle.COLOR)
	private String  others;
	
	
}
