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
