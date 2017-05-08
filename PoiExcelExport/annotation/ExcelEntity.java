package com.ld.datacenter.poi.annotation;

import java.lang.annotation.Documented;
import java.lang.annotation.ElementType;
import java.lang.annotation.Retention;
import java.lang.annotation.RetentionPolicy;
import java.lang.annotation.Target;

import com.ld.datacenter.poi.helper.CellStyle;
import com.ld.datacenter.poi.helper.FontStyle;

/**
 * 标记实体为Excel实体
 */
@Target({ ElementType.TYPE })
@Retention(RetentionPolicy.RUNTIME)
@Documented
public @interface ExcelEntity {
	/**
	 * 年度位置
	 */
	int[] yrPos() default 0;
	/**
	 * 
	 * 年度格子样式
	 */
	CellStyle yrCellStyle() default CellStyle.NONE;
	/**
	 * 年度格子字体
	 */
	FontStyle yrFontStyle() default FontStyle.NONE;
	/**
	 * 季度位置
	 */
	int[] quaPos() default 0;
	/**
	 * 季度格子样式
	 */
	CellStyle quaCellStyle() default CellStyle.NONE;
	
	FontStyle quaFontStyle() default FontStyle.NONE;

	/**
	 * 月份位置
	 */
	int[] monPos() default 0;
	/**
	 * 月份格子样式
	 */
	CellStyle monCellStyle() default CellStyle.NONE;
	
	FontStyle monFontStyle() default FontStyle.NONE;
	/**
	 * 行号
	 */
	int row() default 0;
	/**
	 * 列号
	 */
	int col() default 0;
	
	
}
