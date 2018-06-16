#!/bin/sh
set -e

wget "https://github.com/dotnet/docfx/releases/download/v2.36.2/docfx.zip"
mkdir docfx
unzip docfx.zip -d docfx

mono docfx/docfx.exe ./docs/docfx.json

SOURCE_DIR=$PWD
TEMP_REPO_DIR=$PWD/../monomyst-gh-pages

echo "Removing temporary doc directory $TEMP_REPO_DIR"
rm -rf $TEMP_REPO_DIR
mkdir $TEMP_REPO_DIR

echo "Cloning the repo with the gh-pages branch"
git clone git@github.com:CodeMyst/MonoMyst.git --branch gh-pages $TEMP_REPO_DIR

echo "Clear repo directory"
cd $TEMP_REPO_DIR
git rm -r *

echo "Copy documentation into the repo"
cp -r $SOURCE_DIR/docs/_site/* .

echo "Push the new docs to the remote branch"
git add . -A
git config user.name "Travis CI"
git config user.email "travis@travis-ci.org"
git commit -m "Update generated documentation"

git remote add origin-pages https://${github_access_token}@github.com/CodeMyst/MonoMyst.git > /dev/null 2>&1
git push --quiet --set-upstream origin-pages gh-pages 