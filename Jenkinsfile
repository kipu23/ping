node('jenkins-slave') {
    
     stage('build') {
        sh script: "docker-compose -f docker-compose-build.yaml build --parallel"
    }
}