# Introduction

A command line parser is a class that receives a string s and parser into a TreeNode of a KeyValuePair
with [type, value].

```text
 say hello
```
This turn into a 
- say, index 0, a command. 0|command
- hello, index 1, a value of command. 1|value

We also have a hierachy when we use options for our commands,
example:
```text
say hello -c blue
```

## CommandLineParser class

