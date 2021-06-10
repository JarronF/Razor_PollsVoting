# Razor_PollsVoting
This is a proof of concept poll / voting project. It allows you to add polls with various choices, keeps track of votes cast for those choices and displays the results and when you voted the next time you visit the page. To keep things lean and simple for demonstration purposes, there is no security or authentication of any kind.

#### The project has the following features:
* ASP.NET Razor Pages
* Code-First data models
* EntityFramework Core and LINQ for data access
* MSSQLLocalDB for storage
* TODO: Basic unit testing (xUnit, MOQ)

## Admin Area (Admin.cshtml):

* Basic creation of polls
* Each poll has an expiry date
* Each poll can have multiple choices

![AdminArea](https://user-images.githubusercontent.com/68229225/121529250-82e63a80-c9fc-11eb-829f-552d4b7e0839.png)

## Polls Area (Index.cshtml):

* When a user visits the page, they must be allowed to vote in the provided poll
* Once they have voted, their IP address is logged and they are not allowed to vote again
* If they re-enter the polls page after already voting they should be shown the results so far
* Each choice should indicate how many users have voted for it and the percentage of votes for each choice
* The user should be informed when he entered his vote on that poll, and which vote he selected
* Expired polls are not displayed

![PollResults](https://user-images.githubusercontent.com/68229225/121528632-f3d92280-c9fb-11eb-9906-28a874874c31.png)
