# SuperMegaCalculator

---

[![Docker Pulls](https://img.shields.io/docker/pulls/ramoy/supermegacalculator.svg)](https://hub.docker.com/r/ramoy/supermegacalculator)
[![MIT Licensed](https://img.shields.io/github/license/ramo-y/supermegacalculator.svg)](https://github.com/Ramo-Y/SuperMegaCalculator/blob/master/LICENSE)

---

Hii! This is a super modern and fast calculator!

This is just a shitty implemented NuGet package (SuperMegaCalculator) and is just made as a first attempt with Blazor and for fun.

## What it does
A webapplication which you can use to make basic calculations between 1-10 made with Blazor.

## First look
![FirstLook](https://raw.githubusercontent.com/Ramo-Y/SuperMegaCalculator/master/SuperMegaCalculator.png)

## Installation (Docker)
Use the following docker-compose and replace set your own properties like containername or port
```yaml
version: '3.7'

services:
  supermegacalculator:
    image: ramoy/supermegacalculator:latest
    container_name: "supermegacalculator"
    environment:
      TZ: "Europe/Zurich"
    ports:
      - 4711:80
```

Here is the docker image of this project: https://hub.docker.com/r/ramoy/supermegacalculator