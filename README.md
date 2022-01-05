Resilient Transactional Email Service

Akhil Mujje 1/4/2022

I decided to use C#/.NET Core as the programming language/framework for this exercise as I have been using it extensively at my current job for more
than 3 years and have high proficiency in it.

I spent about 3 hours Monday and 2 hours completing it today. First, I created a new solution and a new project in Visual Studio and began setting
up the basic structure. I created the test request in Postman to trigger this service and hit the endpoint on my local server. 
Then, I created the SendGrid and MailGun accounts and went over their API documentation. Through trial and error, I reproduced the API request for both
SendGrid and MailGun email delivery in Postman. Once I was able to successfully deliver emails, I began to move this functionality over to the code
and began making the data models and services that were needed. After I was able to successfully get both working, I refactored it with
modularity and good design in mind, including basic error handling as well. At all of these steps, I was continuously unit testing.

I hardcoded the secret API keys in to my solution, but that is not secure at all. If this were production, I would have some cloud service
or tool (like Azure KeyVault) to store and access these confidential secrets. In the interest of time, I also implemented basic input validation
and HTML to plain text conversion techniques. If I had more time, I would have written more comprehensive methods to handle all test cases.

This link is the documentation for my Postman requests: https://documenter.getpostman.com/view/6281957/UVXbuf73#7d4f7bb9-79e4-4256-87bf-4f0c68b33dc1

Please let me know if you run into any issues cloning my repo and testing this app. My API keys should work, but if you
modify any email addresses it will not work for at least MailGun because it requires adding authorized recipients.




