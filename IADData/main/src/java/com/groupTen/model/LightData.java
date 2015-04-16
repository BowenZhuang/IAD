//FILE          : LightData.java
//PROJECT       : IAd - Final Project
//PROGRAMMER    : Bowen Zhuang, Linyan Li, Kevin Li
//FIRST VERSION : 2015-04-10
//DESCRIPTION   : This is the POJO of light data 
//
package com.groupTen.model;
import java.util.Date;
public class LightData {
	
	private int id;
	private Date time;
	private int ledRead;
	private int sensorRead;
	
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	public Date getTime() {
		return time;
	}
	public void setTime(Date time) {
		this.time = time;
	}
	public int getLedRead() {
		return ledRead;
	}
	public void setLedRead(int ledRead) {
		this.ledRead = ledRead;
	}
	public int getSensorRead() {
		return sensorRead;
	}
	public void setSensorRead(int sensorRead) {
		this.sensorRead = sensorRead;
	}
	
	
}
