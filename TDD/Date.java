package clock;

public class Date {
	private int theYear = 2000;
	private int theMonth = 1;
	private int theDay = 1;
	public final String outOfBounds = "Out of bounds";


	protected String dateSet(int year, int month, int day) {
		if((year >2100 || year < 2000) || (month > 12 || month < 1) || (day >31 || day <1)) {
			return outOfBounds;
		}
			this.theYear = year;
			this.theMonth = month;
			this.theDay = day; 
		
		return theYear+"-"+theMonth+"-"+theDay; 
	}
	protected String showDate() { 

		return theYear+"-"+theMonth+"-"+theDay;
	}
}
