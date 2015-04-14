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
