# Industry-Project-9
GDT 2022 Third and last [project](https://github.com/Extiriority/Industry-Project-9) about working with stakeholders
<img align="right" src="https://i.imgur.com/z63oDhM.png" width=10%/>

This application helps onboarding people into [Appsemple](https://appsemble.com/en/) specifically for post-secondary vocational education niveau 4 in a gamification manner.

## Goals

* Learn and accelerate how to code blocks by creating an app recipe in a human readable (YAML / JSON) type in a tutorial like gamification principle manner.
* A general framework to build on for having a fun and educational tutorial manner.
* easy to share, copy and customize.

## Development environment set-up

### Windows
On Windows, you will need to install Windows Subsystems for Linux (WSL) in order to run
the PostgreSQL Docker database that CollegeNetwork requires.

1. Enable WSL by going to the `Turn windows features on and off` settings tab
2. Go to the Microsoft Store and install Ubuntu or any distribution of your choosing

### Docker Database setup

1. `CD` into Docker folder
2. Build and start PostgreSQL in port 5432 by running:
```sh
docker build -t collegenetworkpostgres . && docker run -p 5432:5432 --name CollegeNetworkPostgres collegenetworkpostgres 
```
3. Configure the Datasource to PostgreSQL and input the credentials that is located in the Dockerfile

### Environment setup

1. Clone the [Frontend](https://github.com/Extiriority/CollegeNetworkFrontend) repository and
follow the setup instructions in the README
2. Clone this repository
3. Run Frontend and kBackend at the same time, the frontend can then be found at `localhost:3000`
and the API will run at `localhost:8000`
