node{
    stage('SCM Checkout'){
        git credentialsId: 'github', url: 'https://github.com/codescu/Codescu.IDP.git'
    }
    stage('Codescu.IDP'){
        sh 'dotnet build src/Codescu.IDP/Codescu.IDP.csproj'
    }
    stage('Build Codescu.IDP image'){
        sh 'docker build -t mihaimyh/codescu.idp:latest -f src/Codescu.IDP/Dockerfile .'
    }
    stage('Push Codescu.IDP image'){
        withCredentials([usernamePassword(credentialsId: 'docker', passwordVariable: 'dockerPass', usernameVariable: 'dockerUser')]) {
            sh "docker login -u ${dockerUser} -p ${dockerPass}"
        }
        sh 'docker push mihaimyh/codescu.idp:latest'
    }
    stage('Apply deployment script'){
        sh 'kubectl delete -f k8s/1_deploy.yaml'
        sh 'kubectl create -f k8s/1_deploy.yaml'
    }    
    stage('Clean-up docker images and containers'){
        // sh 'docker rmi $(docker images -q)'
        sh 'docker image rm mihaimyh/codescu.idp'
        sh 'docker rmi $(docker images -f "dangling=true" -q)'
        // sh 'docker rm $(docker ps -a -q)'
    }       
}
