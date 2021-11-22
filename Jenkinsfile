node('jenkins-slave') {
    
     stage('build') {
        sh script: "git clone https://github.com/kipu23/ping-pong"
        sh script: "cd ./ping-pong"
        sh script: "docker-compose -f docker-compose.yaml build --parallel"
    }
}