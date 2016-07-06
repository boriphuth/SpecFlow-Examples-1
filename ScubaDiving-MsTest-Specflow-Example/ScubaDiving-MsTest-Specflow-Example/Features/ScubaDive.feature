@scubaDive

Feature: ScubaDive
	This is a feature to demo some basic Specflow Features
	which are all about Scuba Diving since we all love it!

	Executing in MsTest 

Scenario: First Holiday Dive
	Given a new Dive Site named "The Blue Hole"
		And I dive with 2 others
	When I dive a depth of 12 meters for 20 minutes
	Then the sum of the groups time is 60 minutes


Scenario: Names of Multiple Dives Completed in a Day
	Given a new Dive Site named "The Blue Hole"
	When I manage to make it to the Next Dive Site named "The Devil's Throat"
	Then I've dived 
	| Dive Site Name     |
	| The Blue Hole      |
	| The Devil's Throat |


Scenario: Deep Diving Multiple Times Per Day - Total Depth
	Given a new Dive Site named "Multiple Scuba Dives"
	When I dive the following depths in a day: 40, 32, 22, 18, 10, 8, 5
	Then my sum of all depths for the day is 135 meters


Scenario: Deep Diving Multiple Times Per Day - Total Time
	Given a new Dive Site named "Multiple Scuba Dives"
	When I dive the for a time of in minutes: 65, 72, 25, 12, 19, 43, 45
	Then my sum of all times for the day is 281 minutes


Scenario Outline: Dive Tables
	Given a new Dive Site named "<Dive Site Name>"
		And I dive with <Buddies> others
	When I dive a depth of <Depth (meters)> meters for <Time (minutes)> minutes
	Then the sum of the groups time is <Expected Result Sum of Time> minutes

	Examples:

	| Dive Site Name       | Buddies | Depth (meters) | Time (minutes) | Expected Result Sum of Time |
	| The Hermes Shipwreck | 4       | 40             | 60             | 300                         |
	| Lost in Translation  | 1       | 12             | 45             | 90                          |


