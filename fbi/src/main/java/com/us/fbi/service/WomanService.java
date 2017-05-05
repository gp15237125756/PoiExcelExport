package com.us.fbi.service;

import java.sql.SQLException;
import java.util.List;

import org.apache.commons.dbutils.QueryRunner;
import org.apache.commons.dbutils.handlers.BeanListHandler;

import com.us.fbi.DbUtils;
import com.us.fbi.Woman;
import com.us.fbi.dao.WomanDao;

public class WomanService {
	//insert one
	 public void insert() throws SQLException{
		 try{
			 WomanDao dao=new WomanDao();
			 dao.insert();
			 DbUtils.submit();
		 }catch(Exception e){
			 e.printStackTrace();
			 DbUtils.rollback();
		 }finally{
			 DbUtils.closeConnection();
		 }
	 }
	 
	 public void findAll() throws SQLException{
		 	WomanDao dao=new WomanDao();
		 	 List<Woman> ret= dao.findAll();
		 	 DbUtils.closeConnection();
		 	ret.stream().forEach((o)->System.out.println(o));
	}
	 
	 public void update() throws SQLException{
		 try{
			 WomanDao dao=new WomanDao();
			 dao.update();
			 DbUtils.submit();
			 findAll();
		 }catch(Exception e){
			 e.printStackTrace();
			 DbUtils.rollback();
		 }finally{
			 DbUtils.closeConnection();
		 }
	 }
	 
	 public void deleteById() throws SQLException{
		 try{
			 WomanDao dao=new WomanDao();
			 dao.deleteById(4);
			 DbUtils.submit();
			 findAll();
		 }catch(Exception e){
			 e.printStackTrace();
			 DbUtils.rollback();
		 }finally{
			 DbUtils.closeConnection();
		 }
		}
}
