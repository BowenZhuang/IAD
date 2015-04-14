package com.groupTen.dao;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Map;

import org.springframework.jdbc.core.support.JdbcDaoSupport;

import com.groupTen.model.*;
public class GetDataDao extends JdbcDaoSupport {

	private String sql= "select id, dateTime, ledRead, sensorRead from lightControl";
	
	public List<LightData> getData(){
		List<LightData> dataList = new ArrayList<LightData>();
		List<Map> rows = getJdbcTemplate().queryForList(sql);
		for (Map row : rows) {
			LightData data = new LightData();
			data.setId((int)row.get("id"));
			data.setTime((Date)row.get("dateTime"));
			data.setLedRead((int)row.get("ledRead"));
			data.setSensorRead((int)row.get("sensorRead")); 
			dataList.add(data);
		}
		
		return dataList;
	}
	
}
