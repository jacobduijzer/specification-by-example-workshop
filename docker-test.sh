#!/bin/bash

# build the image (even if tests fail, if you used || true)
docker build -t tested-image .

# create a stopped container from it
cid=$(docker create tested-image)

# copy out artifacts
docker cp "$cid":/artifacts ./artifacts

# cleanup
docker rm "$cid"
