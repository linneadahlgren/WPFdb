package tdd;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

class rovarTest {
	rovar rovarClass; 

	@BeforeEach
	void setUp() throws Exception {
		rovarClass = new rovar(); 
	}

	//--------------------------------------------------------------------
	// Tests for Enrov
	@Test
	void testEnrovWithName() {
		assertEquals("LoLinonnonea", rovar.enrov("Linnea")); 
	}
	@Test
	void testEnrovWithNull() {
		assertEquals(null,rovar.enrov(null));  	}
	@Test
	void testEnrovWithEmpty() {
		assertEquals("", rovar.enrov("")); 
	}
	@Test
	void testEnrovWithUpperCaseAlphabet() {
		assertEquals("ABoBCoCDoDEFoFGoGHoHIJoJKoKLoLMoMNoNOPoPQoQRoRSoSToTUVoVWoWXoXYZoZ", rovar.enrov("ABCDEFGHIJKLMNOPQRSTUVWXYZ"));
	}
	@Test
	void testEnrovWithLowerCaseAlphabet() {
		assertEquals("abobcocdodefofgoghohijojkoklolmomnonopopqoqrorsostotuvovwowxoxyzoz", rovar.enrov("abcdefghijklmnopqrstuvwxyz"));	}	
	@Test
	void testEnrovWithNumbers() {
		assertEquals("hohejoj1234DoDå", rovar.enrov("hej1234Då"));
	}
	//-------------------------------------------------------------------
	// Tests for Derov
	@Test
	void testDerovWithName() { 
		assertEquals("Linnea", rovar.derov("LoLinonnonea"));
	}
	@Test
	void testDerovWithNull() {
		assertEquals(null,rovar.derov(null));  
	}
	@Test
	void testDerovWithEmpty() {
		assertEquals("",rovar.derov(""));  
	}
	@Test
	void testDerovWithUpperCaseAlphabet() {
		assertEquals("ABCDEFGHIJKLMNOPQRSTUVWXYZ", rovar.derov("ABoBCoCDoDEFoFGoGHoHIJoJKoKLoLMoMNoNOPoPQoQRoRSoSToTUVoVWoWXoXYZoZ"));
	}
	@Test
	void testDerovWithLowerCaseAlphabet() {
		assertEquals("abcdefghijklmnopqrstuvwxyz", rovar.derov("abobcocdodefofgoghohijojkoklolmomnonopopqoqrorsostotuvovwowxoxyzoz"));
	}
	@Test
	void testDerovWithNumbers() {
		assertEquals("hej1234Då", rovar.derov("hohejoj1234DoDå"));
	}
}
