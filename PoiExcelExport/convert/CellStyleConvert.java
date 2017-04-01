package com.ld.datacenter.poi.convert;

import com.ld.datacenter.poi.extention.XSSFCellStyleLib;
import com.ld.datacenter.poi.extention.XSSFCellStyleRule;
import com.ld.datacenter.poi.extention.impl.XSSFCellStyleRuleImpl;
import com.ld.datacenter.poi.helper.CellStyle;
import com.ld.datacenter.poi.style.ICellStyleFactory;

public class CellStyleConvert implements ICellStyleConvert {
	@Override
	public void convert(CellStyle k, ICellStyleFactory v,XSSFCellStyleLib lib) {
		// TODO Auto-generated method stub
		XSSFCellStyleRule rule=new XSSFCellStyleRuleImpl();
		rule.registerStyleRule(k, v.create(),lib);
	}

}
