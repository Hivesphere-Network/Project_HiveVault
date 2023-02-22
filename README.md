# HiveVault

HiveVault is a knowledge management and data access layer system that is part of the HiveSphere ecosystem. It is designed to provide a central location for storing, managing, and accessing data and information across the HiveSphere platform.
## Features

HiveVault provides a number of features to help organizations manage their data and information more effectively, including:

- Data Storage: HiveVault provides a secure, centralized location for storing data and information across the HiveSphere ecosystem.

- Data Access: HiveVault provides a set of APIs and protocols that allow users to access data and information across the ecosystem, regardless of where it is stored.

- Search: HiveVault includes powerful search functionality that makes it easy to find and retrieve the data and information you need.

- Security: HiveVault uses industry-standard encryption and authentication mechanisms to ensure the security and privacy of your data.

- Scalability: HiveVault is designed to be highly scalable, allowing you to store and manage large amounts of data and information across the ecosystem.
    
## GitHub Actions Status

HiveVault uses GitHub Actions for continuous integration and deployment. The following are the current status of the workflows:  

Build:
    [![GitHub Container Registry Image Build](https://github.com/PramudithaPothuwila/HiveVault/actions/workflows/container-registry-publish.yml/badge.svg?branch=dev)](https://github.com/PramudithaPothuwila/HiveVault/actions/workflows/container-registry-publish.yml)
    [![Docker Hub Container Image Library Image Build](https://github.com/PramudithaPothuwila/HiveVault/actions/workflows/docker-hub-publish.yml/badge.svg)](https://github.com/PramudithaPothuwila/HiveVault/actions/workflows/docker-hub-publish.yml)  
Tests:   
Deploy:

Note: The build and test workflows are triggered automatically when changes are pushed to the repository. The deploy workflow is triggered manually when a new version of the application is ready to be deployed to production.
