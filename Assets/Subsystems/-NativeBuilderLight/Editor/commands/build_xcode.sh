echo "cd $1"
cd $1

# 删除已存在的ipa文件，多个ipa可能会让人觉得迷惑
echo "rm build/*.ipa"
rm build/*.ipa

echo "rm ./build/*.xcarchive"
rm build/*.xcarchive

#clean xcode
echo "xcodebuild clean -project Unity-iPhone.xcodeproj -scheme Unity-iPhone -configuration Release"
xcodebuild clean -project Unity-iPhone.xcodeproj -scheme Unity-iPhone -configuration Release

#生成xcarchive备用
echo "xcodebuild archive -project Unity-iPhone.xcodeproj -scheme Unity-iPhone -archivePath ./export/Unity-iPhone.xcarchive"
xcodebuild archive -project Unity-iPhone.xcodeproj -scheme Unity-iPhone -archivePath ./export/Unity-iPhone.xcarchive

#Build ipa
echo "xcodebuild -exportArchive -archivePath  ./export/Unity-iPhone.xcarchive -exportPath ./export -exportOptionsPlist ../../NativeBuilderConf/script/ipa.plist"
xcodebuild -exportArchive -archivePath  ./export/Unity-iPhone.xcarchive -exportPath ./export -exportOptionsPlist ../../NativeBuilderConf/script/ipa.plist

# 检查xcodebuild是否成功
ret=$?
if [[ $ret != 0 ]]; then
	echo "[build-xcode]: Failed, xcodebuild returns $ret"
	exit $ret
fi