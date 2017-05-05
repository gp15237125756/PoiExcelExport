package com.us.fbi.dao;

import java.sql.SQLException;
import java.util.List;

import org.apache.commons.dbutils.QueryRunner;
import org.apache.commons.dbutils.handlers.BeanListHandler;
import org.apache.commons.dbutils.handlers.ScalarHandler;

import com.us.fbi.DbUtils;
import com.us.fbi.Woman;

public class WomanDao {
	/* add new woman*/
	public void insert() throws SQLException{
		String sql="insert into woman (name,age,sex,vagina) values (?,?,?,?)";
		QueryRunner runner=new QueryRunner();
		Long result=runner.insert(DbUtils.getConnection(),sql, new ScalarHandler<Long>(),"ivanka Trump",30,false,false);
		System.out.println(result);
	}
	
	public List<Woman> findAll() throws SQLException{
		String sql="select * from  woman";
		QueryRunner runner=new QueryRunner();
		List<Woman> result=runner.query(DbUtils.getConnection(),sql, new BeanListHandler<Woman>(Woman.class));
		return result;
	}
	
	public int update() throws SQLException{
		String sql="update woman set vagina=?";
		QueryRunner runner=new QueryRunner();
		return runner.update(DbUtils.getConnection(),sql, true);
	}
	
	public int deleteById(int id) throws SQLException{
		String sql="delete from woman where id=?";
		QueryRunner runner=new QueryRunner();
		return runner.update(DbUtils.getConnection(),sql, id);
	}
}
