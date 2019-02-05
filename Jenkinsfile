#!/usr/bin/env groovy
library 'jenkins-pipeline-library'

def projectName = "generic-exchange-transport-agent"
def useVersion = version.uniqueBuildVersion()

def	pipelineConfiguration = [
	config: [
		project: "${projectName}-build",
		debug: true,
		spinnakerName: "${projectName}",
		rocketChat: [
			channel: "kubedemo"
		],
		delivery: [
			files: [
				"**/*.msi": [
					archive: [
						enabled: true,
						mustExist: true
					],
					spinnaker: [
						type: "windows/msi",
						name: "${projectName}",
						reference: "${projectName}.msi",
						version: "${useVersion}"
					]
				],
			]
		]
	]
]

def workflow = workflow.createFromPipelineConfiguration(pipelineConfiguration)
workflow.context.config["type"] = ".NET binary build"
def msBuildConfiguration = msBuildConfiguration.create(workflow.context)

pipeline {
	agent {
		label 'dotnet'
	}
	
	parameters {
		choice(name: 'BUILD_TARGET', choices: ['2010', '2016 RTM'], description: "Which Exchange version to use as build target, defaults to 2010")
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
					def useCommitHash = version.shortGitCommitHash()
					
					bat "powershell -File set-ci-versions.ps1 -BuildNumber ${useVersion} -Revision ${useCommitHash}"
					bat "powershell -File build.ps1 -BuildTarget ${params.BUILD_TARGET} -ExchangeLibrariesPath c:\\exchange-libs"
				}
			}
		}
		
		stage('Deliver artifacts to WooCommerce shop') {
			steps {
				script {
					workflow.deliveryStage.run()
				}
			}
		}

		stage('Collect delivered artifacts (local archiving, Spinnaker properties)') {
			steps {
				script {
					workflow.archiveStage.run()
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

		/*
		cleanup {
			script {
				cleanWs()
			}
		}
		*/
	}
}
