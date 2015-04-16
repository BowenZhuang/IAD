//FILE          : Light.java
//PROJECT       : IAd - Final Project
//PROGRAMMER    : Bowen Zhuang, Linyan Li, Kevin Li
//FIRST VERSION : 2015-04-10
//DESCRIPTION   : This is the POJO of light data 
//
package com.groupTen.service;

import java.util.List;

import com.groupTen.dao.GetDataDao;
import com.groupTen.model.LightData;

public class GetDataService {
	
	private GetDataDao dao;

	public GetDataDao getDao() {
		return dao;
	}

	public void setDao(GetDataDao dao) {
		this.dao = dao;
	}
	
	public List<LightData> getDataList(){
		List<LightData> dataList =dao.getData();
		return dataList;
		
	}

	public List<LightData> getOneList() {
		List<LightData> dataList =dao.getOneData();
		return dataList;
	}
	
	
}
