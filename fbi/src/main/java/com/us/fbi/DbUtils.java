package com.us.fbi;

import java.beans.PropertyVetoException;
import java.sql.Connection;
import java.sql.SQLException;

import com.mchange.v2.c3p0.ComboPooledDataSource;

/**
 * encapsulate database 
 * @author Cruz
 * @version 01-00
 *
 */
public class DbUtils {
	/**连接池*/
	private static ComboPooledDataSource dataSource=null;
	/**连接*/
	private static ThreadLocal<Connection> tl=new ThreadLocal<Connection>();
	
	static{
		dataSource=new ComboPooledDataSource();
		try {
			dataSource.setDriverClass("com.mysql.jdbc.Driver");
			dataSource.setJdbcUrl("jdbc:mysql://localhost:3306/test");
			dataSource.setUser("root");
			dataSource.setPassword("root");
			dataSource.setInitialPoolSize(10);
			dataSource.setMinPoolSize(5);
			dataSource.setMaxPoolSize(100);
		} catch (PropertyVetoException e) {
			e.printStackTrace();
		}
	}
	/**get connection,open transaction*/
	public static Connection getConnection() throws SQLException{
		Connection conn=tl.get();
		if(null==conn){
			conn=dataSource.getConnection();
			tl.set(conn);
		}
		if(conn.getAutoCommit()){
			conn.setAutoCommit(false);
		}
		return conn;
	}
	
	public static void submit() throws SQLException{
		Connection conn=tl.get();
		if(null!=conn){
			conn.commit();
		}
	}
	
	public static void rollback() throws SQLException{
		Connection conn=tl.get();
		if(null!=conn){
			conn.rollback();
		}
	}
	
	public static void closeConnection() throws SQLException{
		Connection conn=tl.get();
		if(null!=conn){
			conn.close();
			tl.remove();
		}
	}

	public static ComboPooledDataSource getDataSource() {
		return dataSource;
	}

	public static void setDataSource(ComboPooledDataSource dataSource) {
		DbUtils.dataSource = dataSource;
	}
	
	

}
