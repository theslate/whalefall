@echo off
git add * -n | sed "s/.*\.//" | sed "s/'//" | sort | uniq
