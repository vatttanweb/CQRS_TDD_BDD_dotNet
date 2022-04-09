# CQRS_TDD_BDD_dotNet
Simple project for implement CQRS with TDD and BDD by SQLSerer and EventStoreDb.

The tuturial of this project will be posted in my [Medium](https://medium.com/@dizaji.akbar).
----------------------------------------------------------------------------------------------
What will be complete:

1.Complete All tests.(Now,Just 2 of them done for showing approach)

2.Complete All Behaviours in SpecFlow(Now, just 1 of them done for showing approach)

3.Refactoring.For example:


-Builder Pattern for create instance of customer.

-Pipe&Filter for "if clauses" in "validationProxy".

-----------------------------------------------------------------------------------------------

In some situation we have more than one solution.For example:

-For Sync CommandDb and QueryDb:

+Sync in period of time with jobs

+use projection

+use event for syncing in each time that command raise.(This was used)

-Validation(For get correct type we use FluentValidate in Mediatr but for db validation:) :

+Use Saga

+First of all,read and check data from query side and then write.(This was used)

----------------------------------------------------------------------------------------

Note:This project doesnt actualy change state of entity and there is not any event for sourcing and event sourcing just be used for show approach.
Because of this I choose above solutions. If for example we have another field like
assets and with buy/sell this field chenged,So another solutions will be used.
