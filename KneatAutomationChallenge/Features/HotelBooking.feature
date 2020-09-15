Feature: Booking
	In order to Book a Hotel 
	As a traveler
	I want to be able to filter the criteria based on Spa and Wellness along with Star rating.

@mytag
Scenario: Hotel Booking

	Given Traveler wants to Book Hotel
	When Traveler searches to Book Hotel in '<Location1>' 
	Then Traveler selects the Date after '3' Months along with number of person with room and make a Search
	And Traveler Filters by '<Filter>' and Validate Results '<HotelName>' with result as '<IsListed>'
	
	Examples: 
	| Location1 | Filter | HotelName | IsListed |
	| Limerick  |  Sauna |Maldron Hotel & Leisure Centre Limerick | passed  |
	| Limerick  |  Sauna |George Strand Hotel | failed   |
	| Limerick  |  5 star |The Savoy Hotel | passed   |
	| Limerick  |  5 star |George Limerick Hotel | failed   |

	