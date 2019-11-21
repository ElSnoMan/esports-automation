# Welcome to the esports-automation Repo!
This is the repo that is paired with my Test Automation University course called _Scaling Tests with Docker._

> IMPORTANT: The repo will look different because it's easier to update the repo than the videos in the course. Please make sure to read the entire README. Thanks :)


## How do I get started?
1. Download the .NET Core 2.2 or greater SDK and install it on your machine.
    - https://dotnet.microsoft.com/download/dotnet-core/2.2
    - Click on .NET Core Installer

2. Clone or fork this repo and open it in either Visual Studio Community or VS Code.

3. Then, in your terminal, make sure to `cd` into the `Esports` directory

    ```bash
    $ cd <your-path>/esports-automation/Esports
    ```

4. You're good to go!

## Running the tests

Since the course was recorded, running tests have changed a bit.

1. There is no longer a `.runsettings` file in the repo. This has been replaced with the `config.json` and is consumed in the `FW.cs` file.

2. How you execute the tests is different too. Check out the commands below.


This command is used to run tests with the Category of `demo`. This is currently only two tests in the Standings suite.

```bash
$ dotnet test --filter testcategory=demo
```

Similar to the command above, but this is used to run all of the tests in the Standings suite.

```bash
$ dotnet test --filter testcategory=standings
```

I put this here in case you wanted to run tests by name. This command run all tests that have `lcs` in their name (not case-sensitive).

```bash
$ dotnet test --filter lcs
```

Microsoft's documentation on their `dotnet test` command can be found here:
- https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test


## Questions or Feedback
Please feel free to reach out to me using any of these:

- LinkedIn: https://www.linkedin.com/in/carlos-kidman/
- Twitter: @CarlosKidman
- YouTube: https://www.youtube.com/channel/UCNvYBOCETf7MByrYKDTU3fQ
