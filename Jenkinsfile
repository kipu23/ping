node('jenkins-slave') {
    
     stage('build') {
        sh script: "docker-compose -f docker-compose.yaml build --parallel"
    }
}