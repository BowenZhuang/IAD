package com.groupTen.dao;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Map;

import org.springframework.jdbc.core.support.JdbcDaoSupport;

import com.groupTen.model.*;
public class GetDataDao extends JdbcDaoSupport {

	private String sql = "select id, dateTime, ledRead, sensorRead from lightControl";
	
	private String sqlOne = "select id, dateTime, ledRead, sensorRead from lightControl order by id desc limit 1 ";
	
	public List<LightData> getData(){
		List<LightData> dataList = new ArrayList<LightData>();
		List<Map> rows = getJdbcTemplate().queryForList(sql);
		for (Map row : rows) {
			LightData data = new LightData();
			data.setId(((Integer)row.get("id")).intValue());
			data.setTime((Date)row.get("dateTime"));
			data.setLedRead(((Integer)row.get("ledRead")).intValue());
			data.setSensorRead(((Integer)row.get("sensorRead")).intValue()); 
			dataList.add(data);
		}
		
		return dataList;
	}
	
	public List<LightData> getOneData(){
		List<LightData> dataList = new ArrayList<LightData>();
		List<Map> rows = getJdbcTemplate().queryForList(sqlOne);
		for (Map row : rows) {
			LightData data = new LightData();
			data.setId(((Integer)row.get("id")).intValue());
			data.setTime((Date)row.get("dateTime"));
			data.setLedRead(((Integer)row.get("ledRead")).intValue());
			data.setSensorRead(((Integer)row.get("sensorRead")).intValue()); 
			dataList.add(data);
		}
		
		return dataList;
	}
}
