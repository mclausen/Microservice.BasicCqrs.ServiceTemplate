# _BoundedContext_ Readme

## Badge

![Build status](https://umbraco.visualstudio.com/Cloud%20vNext/_apis/build/status/Build%20_BoundedContext_)
 <-- Configure build Pipeline should be named 'Build _BoundedContext_'.

## Table of Contents
- [_BoundedContext_ Bounded context](#_BoundedContext_-Bounded-context)
- [Build](#build)
- [Install](#Install)
	- [Restore](#Restore)
    - [Test](#Test)
    - [Run Locally](#Run-locally)
- [Solution](#Solution)
    - [Nuget](#nuget)
    - [Clean Arhitecture](#clean-architecture)
    - [Worker Service](#worker-service)
    - [Api Service](#api-service)

## _BoundedContext_ Bounded context

What is the back ground and responsibilities of this _BoundedContext_ Bounded context?

> Your documentation is complete when someone can use your module without ever
having to look at its code. This is very important. This makes it possible for
you to separate your module's documented interface from its internal
implementation (guts). This is good because it means that you are free to
change the module's internals as long as the interface remains the same.

> Remember: the documentation, not the code, defines what a module does.

~ [Ken Williams, Perl Hackers](http://mathforum.org/ken/perl_modules.html#document)

Writing READMEs is way too hard, and keeping them maintained is difficult. By offloading this process - making writing easier, making editing easier, making it clear whether or not an edit is up to spec or not - you can spend less time worry about whether or not your initial documentation is good, and spend more time writing and using code.

As well, standardizing can help elsewhere. By having a standard, users can spend less time searching for the information they want. They can also build tools to gather search terms from descriptions, to automatically run example code, to check licensing, and so on.

The goals for this repository are:

1. A well defined **specification**. This can be found in the [Spec document](spec.md). It is a constant work in progress; please open issues to discuss changes.
2. **An example README**. This Readme is fully standard-readme compliant, and there are more examples in the `example-readmes` folder.
3. A **linter** that can be used to look at errors in a given Readme. Please refer to the [tracking issue](https://github.com/RichardLitt/standard-readme/issues/5).
4. A **generator** that can be used to quickly scaffold out new READMEs. See [generator-standard-readme](https://github.com/RichardLitt/generator-standard-readme).
5. A **compliant badge** for users. See [the badge](#badge).

## Install

This project uses [dotnet core](https://dotnet.microsoft.com/download) and [Docker](https://www.docker.com/). Go check them out if you don't have them locally installed.

### Restore
```sh
$ dotnet restore
# Restores nuget packages
```

### Test
```sh
$ dotnet test
# Runs the test
```

### Run Locally
```sh
$ dotnet run
# Runs the applications
```

### Docker
Docker documentation goes here

## Solution

### Logging
The solutions is configured to use Serilog together with Application Insights

### Nuget
Nuget.config specifies which sources are available for this repository.
As of now we get packages from two different sources
Umbraco internal nuget feed and Nuget.Org

> Umbraco internal nuget feed requires Credentials for Azure DevOps

### Clean Architecture

### Worker Service
Is a queue based service build on [Rebus](https://github.com/rebus-org/Rebus).

#### Configuration
The service represents two queues

- _BoundedContext_-_ServiceName_-input
- _BoundedContext_-_ServiceName_-error

### Api Service


### _BoundedContext_ Eventemitter