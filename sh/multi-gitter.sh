#!/bin/bash

# use of https://github.com/lindell/multi-gitter

multi-gitter run ./notice-stuff.sh --log-level=debug \
-R org/repo-name \
-m "commit-msg" -B phillip.branch-name --token some-gh-token