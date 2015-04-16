//FILE          : JsonAction.java
//PROJECT       : IAd - Final Project
//PROGRAMMER    : Bowen Zhuang, Linyan Li, Kevin Li
//FIRST VERSION : 2015-04-10
//DESCRIPTION   : This is the action class which deals with http request call service layer to prepare data  
//
 
package com.groupTen.action;
 

import com.groupTen.model.*;
import com.groupTen.service.GetDataService;

import java.util.List;

import org.apache.struts2.json.annotations.JSON;

import com.opensymphony.xwork2.Action;
import com.opensymphony.xwork2.ActionSupport;

public class JsonAction extends ActionSupport{

	
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private GetDataService dataService;
	@JSON(serialize=false)
	public GetDataService getDataService() {
		return dataService;
	}
	public void setDataService(GetDataService dataService) {
		this.dataService = dataService;
	}

	
	private List<LightData> dataList;
	public void setDataList(List<LightData> dataList) {
		this.dataList = dataList;
	}
	@JSON(name="data")
	public List<LightData> getDataList() {
		return dataList;
	}
	 
	
	@JSON(serialize=false)
	public String execute(){

		dataList=dataService.getDataList();

		return Action.SUCCESS;

	}
	@JSON(serialize=false)
	public String getOne(){
		
		dataList=dataService.getOneList();

		return Action.SUCCESS;
		
	}
}