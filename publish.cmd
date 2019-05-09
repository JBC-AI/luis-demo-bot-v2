nuget restore
msbuild CoreBot.sln -p:DeployOnBuild=true -p:PublishProfile=rosie-bot-Web-Deploy.pubxml -p:Password=FsQnYkfNbCeYLaakXkXXBwiMCMNwg302z6HqbJdlFb89M6EtL1bFjRax4SvL

