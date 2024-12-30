# WhiteBrookAPI

Sample .Net 8.0 web api project running in docker

Run Docker :
		http://localhost:5000/index.html
		https://localhost:5001/index.html

		Requirements/ Preliminaries
			- Docker Desktop running as Linux containers. Required for images dotnet/sdk:8.0-jammy and dotnet/aspnet:8.0-jammy.
			- OpenSSL
			- .env : Used for injecting certficate password into the docker container.
				- Add the .env Package : dotnet add package DotNetEnv
				- Create a .env at project root and add a password
						# .env
						# ASPNETCORE_Kestrel__Certificates__Default__Password=<YOUR_SECURE_PASSWORD>
				- Don't forget to add .env to .gitignore
			
			- Local self-signed SSL certificate
				- Clean/ clear any local dev certs
					> dotnet dev-certs https --clean
				- Create self signed cert
					> dotnet dev-certs https -ep ./aspnetapp.pfx -p <YOUR_SECURE_PASSWORD>
				- Create a .crt file
						> openssl pkcs12 -in aspnetapp.pfx -clcerts -nokeys -out aspnetapp.crt -passin pass:<YOUR_SECURE_PASSWORD>
				- Add .crt file to local trusted root certificate store
					> RUN > certlm.msc > Trusted Root Certification Authorities > Certificates > Right Click > Import...
            - Build and Serve docker container
                > docker-compose up --build
                Check out http://localhost:5000/index.html and 
		        https://localhost:5001/index.html