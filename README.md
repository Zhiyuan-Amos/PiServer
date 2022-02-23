# Developer Guide

## Build

Generate the output files by on the development machine:

```
dotnet publish -r linux-arm
```

## Host

Transfer the output files to the Raspberry Pi by running on the development machine:

```
scp -r .\bin\Debug\net6.0\linux-arm\* pi@{ipAddr}:{path}
```

Host this server locally by running on the Raspberry Pi:

```
chmod +x {path}/PiServer
sudo {path}/PiServer --urls "http://localhost:80"
```

## Exposing to Public Internet

The previous step only allows local access to the server. For GitHub Actions to reach it, the server has to be exposed to the public Internet. Use `Ngrok` to do so by running this on the Raspberry Pi:

```
cd ~
wget https://bin.equinox.io/c/4VmDzA7iaHb/ngrok-stable-linux-arm.tgz
tar -xvzf ngrok-stable-linux-arm.tgz
```

Then, create an account on `ngrok`, retrieve the `authToken` and run:

```
./ngrok authtoken {authToken}
./ngrok http -bind-tls=true 80
```

The server can now be reached at the url specified by the `Forwarding` header.
