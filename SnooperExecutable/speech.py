import requests
import sys
import os

arg1 = sys.argv[1]
k = arg1.rfind("\\")
fileName = arg1[k+1:]

os.system('gsutil cp -a public-read "' + arg1 + '" gs://audio-portal')

# Set these according to your needs
speech_api_url = 'https://speech.googleapis.com/v1/speech:recognize?key=AIzaSyDKZ6JOU1Cr6_tXpmZKFdwiaBugaya0lpI'
database_api_url = ''

transcript_response = requests.post(speech_api_url, data = "{ 'config' : { 'languageCode' : 'en-US' },'audio' : { 'uri' : 'gs://audio-portal/"+ fileName +"' } }")
database_post_response = requests.post(database_api_url, data = transcript_response.text[:-1] + ", \"audioUrl\" : \"gs://audio-portal/" + fileName + "\" }")

#f = open('C:\\Users\\tspao\\Desktop\\' + fileName + '.txt', 'w+')
#f.write(transcript_respose.text)
#f.close()