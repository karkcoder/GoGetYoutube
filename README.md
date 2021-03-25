# GoGetYoutube


## Docker Build
### Run the commmand below from the dockerfile path

`docker build -t gogetyoutube .`

## Docker Run
### Mounting local /mnt/NAS drive to the docker container path at /mnt/NAS
### Exposing port 80 (make sure the firewall has port 80 opened, if you have ufw, use sudo ufw allow http. Since this is local, I am not using https port.

`docker run --name=gogetyoutube -d -v /mnt/NAS:/mnt/NAS -p 80:80 gogetyoutube`
