#!/bin/sh
docker rm -f nina_home
docker rmi nina_home
docker load -i ./nina_home.tar
docker run --name nina_home -d --restart always --network host -v /data/nina_home/configs.json:/app/configs.json nina_home