#!/usr/bin/env groovy
library 'jenkins-pipeline-library'

def projectName = "generic-exchange-transport-agent"

def	pipeline = [
	config: [
		project: "${projectName}-build",
		debug: true,
		spinnakerName: "${projectName}",
		rocketChat: [
			channel: "kubedemo"
		],
	]
]

def workflow = workflow.createFromPipelineConfiguration(pipeline)
workflow.context.config["type"] = ".NET binary build"
def msBuildConfiguration = msBuildConfiguration.create(workflow.context)

pipeline {
	node {
		label 'dotnet'
	}
	
	stages {
		stage('Configure') {
			steps {
				script {
					workflow.configure(this)
				}
			}
		}


		stage('Checkout and import') {
			steps {
				script {
					workflow.initStage.run()
				}
			}
		}

		stage('Compile') {
			steps {
				script {
					bat "\"${msBuildConfiguration.bin}\" Geta.sln /r:True"
				}
			}
		}
	}
	
	post {
		unstable {
			script {
				workflow.context.notifier.fail([title: 'Build Status', text: 'Build is unstable :-/'])
			}
		}

		failure {
			script {
				workflow.context.notifier.fail([title: 'Build Status', text: 'Build failed :-/'])
			}
		}
			
		success {
			script {
				workflow.context.notifier.ok([title: 'Build Status', text: 'Build succeeded :-)'])
			}
		}

		cleanup {
			script {
				cleanWs()
			}
		}
	}
}
