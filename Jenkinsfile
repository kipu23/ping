node('jenkins-slave') {
    
     stage('build') {
        sh(script: """
            echo "pipeline start"
            git clone https://github.com/kipu23/ping-pong
            cd ./ping-pong
            docker-compose -f docker-compose.yaml build --parallel
        """)
    }
}