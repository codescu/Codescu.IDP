node{
    stage('SCM Checkout'){
        git credentialsId: 'github', url: 'https://github.com/codescu/Codescu.IDP.git'
    }
    stage('Build Codescu.IDP.Admin docker image'){
        sh 'docker build -t mihaimyh/codescuadminui:latest -f src/Codescu.IDP.Admin/Dockerfile .'
    }
    stage('Push Codescu.IDP docker image'){
        withCredentials([usernamePassword(credentialsId: 'docker', passwordVariable: 'dockerPass', usernameVariable: 'dockerUser')]) {
            sh "docker login -u ${dockerUser} -p ${dockerPass}"
        }
        sh 'docker push mihaimyh/codescuadminui:latest'
    }
    stage('Build Codescu.IDP.STS.Identity docker image'){
        sh 'docker build -t mihaimyh/codescu.idp:latest -f src/Codescu.IDP.STS.Identity/Dockerfile .'
    }
    stage('Push Codescu.IDP docker image'){
        withCredentials([usernamePassword(credentialsId: 'docker', passwordVariable: 'dockerPass', usernameVariable: 'dockerUser')]) {
            sh "docker login -u ${dockerUser} -p ${dockerPass}"
        }
        sh 'docker push mihaimyh/codescu.idp:latest'
    }    
    stage('Apply deployment script'){
        sh 'kubectl delete -f k8s/7_idsrv_admin_deploy.yaml'
        sh 'kubectl create -f k8s/5_idsrv_deploy.yaml'
    }    
    stage('Clean-up docker images and containers'){
        // sh 'docker rmi $(docker images -q)'
        sh 'docker image rm mihaimyh/codescu.idp'
        sh 'docker image rm mihaimyh/codescuadminui'
        sh 'docker rmi $(docker images -f "dangling=true" -q)'
        // sh 'docker rm $(docker ps -a -q)'
    }       
}