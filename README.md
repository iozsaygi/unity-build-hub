# Unity Build Hub
Unity Build Hub is a DevOps and continuous integration utility for the Unity engine to provide built-in build operations to third-party tools such as [Jenkins](https://www.jenkins.io/) and [TeamCity](https://www.jetbrains.com/teamcity/).

## Prerequisites
* [Unity](https://unity.com/) 2022.3 or higher
* Build server running Jenkins or TeamCity

## Supported build operations
* MacOS x64 IL2CPP
* Windows x64 Mono
* Windows x64 IL2CPP
* Android Mono
* Android IL2CPP

## Installation
* Add package from git URL ``https://github.com/iozsaygi/unity-build-hub.git`` or download the [latest release](https://github.com/iozsaygi/unity-build-hub/releases/latest)

## Jenkins item configuration
Assuming the Jenkins instance Unity Build Hub is working on already has the [Unity3d](https://plugins.jenkins.io/unity3d-plugin/) plugin installed, this is how Unity Build Hub can be linked to the Jenkins item that produces builds by using the Unity engine.
![Jenkins Item Configuration](https://github.com/iozsaygi/unity-build-hub/blob/main/Images/JenkinsItemConfiguration.png?raw=true)
Notice how we exactly added the path to the function that triggers MacOS builds in the command line arguments for Jenkins item configuration.

## Changelog
Please see [CHANGELOG](https://github.com/iozsaygi/unity-build-hub/blob/main/CHANGELOG.md) for detailed information.

## License
[MIT License](https://github.com/iozsaygi/unity-build-hub/blob/main/LICENSE)