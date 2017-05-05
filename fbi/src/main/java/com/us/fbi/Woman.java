package com.us.fbi;
/**
 * Woman　ENTITY
 * @author Cruz
 * @version 01-00
 * @Date 2017-5-5 14:10
 *
 */
public class Woman {
	
	private Long id;
	
	private String name;
	
	private boolean sex;
	
	private Integer age;
	
	private boolean vagina;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public boolean isSex() {
		return sex;
	}

	public void setSex(boolean sex) {
		this.sex = sex;
	}

	public Integer getAge() {
		return age;
	}

	public void setAge(Integer age) {
		this.age = age;
	}

	public boolean isVagina() {
		return vagina;
	}

	public void setVagina(boolean vagina) {
		this.vagina = vagina;
	}

	@Override
	public String toString() {
		return "Woman [id=" + id + ", name=" + name + ", sex=" + sex + ", age="
				+ age + ", vagina=" + vagina + "]";
	}
	
	
}
