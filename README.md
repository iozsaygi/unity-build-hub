# Unity Build Hub
Unity Build Hub is a DevOps and continuous integration utility for the Unity engine to provide built-in build operations to third-party tools such as [Jenkins](https://www.jenkins.io/) and [TeamCity](https://www.jetbrains.com/teamcity/).

## Prerequisites
* [Unity](https://unity.com/) 2022.3 or higher
* Build server running Jenkins or TeamCity

## Installation
* Add package from git URL ``https://github.com/iozsaygi/unity-build-hub.git`` or download the [latest release](https://github.com/iozsaygi/unity-build-hub/releases/latest)

## Jenkins configuration
Assuming the Jenkins instance Unity Build Hub is working on already has the [Unity3d](https://plugins.jenkins.io/unity3d-plugin/) plugin installed, this is how Unity Build Hub can be linked to the Jenkins item that produces builds by using the Unity engine.
![Jenkins Item Configuration](https://github.com/iozsaygi/unity-build-hub/blob/main/Images/JenkinsItemConfiguration.png?raw=true)

## Changelog
Please see [CHANGELOG](https://github.com/iozsaygi/unity-build-hub/blob/main/CHANGELOG.md) for detailed information.

## License
[MIT License](https://github.com/iozsaygi/unity-build-hub/blob/main/LICENSE)